using Or.Business;
using Or.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;
using static Or.Business.MessagesErreur;

namespace Or.Pages
{
    /// <summary>
    /// Logique d'interaction pour Virement.xaml
    /// </summary>
    public partial class Virement : PageFunction<long>
    {
        Carte CartePorteur { get; set; }
        Compte ComptePorteur { get; set; }

        // Numéro de carte du propriétaire du compte 
        private long NumCarteClient { get; set; }


        public Virement(long numCarte)
        {
            InitializeComponent();

            Montant.Text = 0M.ToString("C2");

            CartePorteur = SqlRequests.InfosCarte(numCarte);
            CartePorteur.AlimenterHistoriqueEtListeComptes(SqlRequests.ListeTransactionsAssociesCarte(numCarte), SqlRequests.ListeComptesAssociesCarte(CartePorteur.Id).Select(x => x.Id).ToList());
            ComptePorteur = SqlRequests.ListeComptesAssociesCarte(CartePorteur.Id).Find(x => x.TypeDuCompte == TypeCompte.Courant);

            // Pour Compte à débiter
            var viewExpediteur = CollectionViewSource.GetDefaultView(SqlRequests.ListeComptesAssociesCarte(numCarte));
            viewExpediteur.GroupDescriptions.Add(new PropertyGroupDescription("TypeDuCompte"));
            viewExpediteur.SortDescriptions.Add(new SortDescription("TypeDuCompte", ListSortDirection.Ascending));
            viewExpediteur.SortDescriptions.Add(new SortDescription("IdentifiantCarte", ListSortDirection.Ascending));
            Expediteur.ItemsSource = viewExpediteur;

            // Pour compte à créditer 
            var viewDestinataire = CollectionViewSource.GetDefaultView(listvirement());
            viewDestinataire.GroupDescriptions.Add(new PropertyGroupDescription("IdentifiantCarte"));
            viewDestinataire.SortDescriptions.Add(new SortDescription("IdentifiantCarte", ListSortDirection.Ascending));
            viewDestinataire.SortDescriptions.Add(new SortDescription("TypeDuCompte", ListSortDirection.Ascending));
            Destinataire.ItemsSource = viewDestinataire;
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            OnReturn(null);
        }

        // Renvoi à la méthode ajout bénéficiaire dans le fichier Ajout.Benef.xaml.cs
        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {        
            PageFunctionNavigate(new AjoutBenef(CartePorteur.Id));
        }

        void PageFunctionNavigate(PageFunction<long> page)
        {
            page.Return += new ReturnEventHandler<long>(PageFunction_Return);
            NavigationService.Navigate(page);
        }

        void PageFunction_Return(object sender, ReturnEventArgs<long> e)
        {
            
        }

        private void ValiderVirement_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(Montant.Text.Replace(".", ",").Trim(new char[] { '€', ' ' }), out decimal montant))
            {
                Compte ex = Expediteur.SelectedItem as Compte;
                Compte de = Destinataire.SelectedItem as Compte;

                Transaction t = new Transaction(0, DateTime.Now, montant, ex.Id, de.Id);
                CodeResultat codeResultat;

                if (((codeResultat = (Expediteur.SelectedItem as Compte).EstRetraitValide(t)) == CodeResultat.transactionok) && ((codeResultat = CartePorteur.EstRetraitAutoriseNiveauCarte(t, ex, de)) == CodeResultat.transactionok))
                {
                    SqlRequests.EffectuerModificationOperationInterCompte(t, ex.IdentifiantCarte, de.IdentifiantCarte);
                    OnReturn(null);
                }
                else
                {
                    MessageBox.Show(MessagesErreur.Label(codeResultat));
                }
            }
            else
            {
                MessageBox.Show(MessagesErreur.Label(CodeResultat.montanttinvalide));
            }

        }

        // Mise à jour des comptes à créditer avec la listevirement
        public void Expediteur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewDestinataire = CollectionViewSource.GetDefaultView(listvirement());
            viewDestinataire.GroupDescriptions.Add(new PropertyGroupDescription("IdentifiantCarte"));
            viewDestinataire.SortDescriptions.Add(new SortDescription("IdentifiantCarte", ListSortDirection.Descending));
            viewDestinataire.SortDescriptions.Add(new SortDescription("TypeDuCompte", ListSortDirection.Ascending));
            Destinataire.ItemsSource = viewDestinataire;
        }

        // Liste des comptes pouvant être créditer pour le virement
        public List<Compte> listvirement()
        {
            List<Compte> totalCompte = new List<Compte>();

            if (Expediteur.SelectedItem != null)
            {
               // if (Expediteur.SelectedItem != )
                int idExp = (Expediteur.SelectedItem as Compte).Id;

                // Liste compte associé à la carte
                var compteClient = SqlRequests.ListeComptesAssociesCarte(CartePorteur.Id).Where(c => c.Id != idExp).ToList();
                // Liste compte bénéficiaires 
                var compteBenef = SqlRequests.ListeBeneficiairesAssocieClient(CartePorteur.Id).SelectMany(b => SqlRequests.ListeComptesAssociesCarte(b.NumCarteBenef)).Where(c => c.Id != idExp).Where(d => d.TypeDuCompte == TypeCompte.Courant).ToList();
                // Fusion des deux listes
                
                totalCompte = compteClient.Concat(compteBenef).ToList();
            }
            return totalCompte;
        }

    }
}
