using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Or.Business;
using Or.Models;
using System.ComponentModel;



namespace Or.Pages
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class AjoutBenef : PageFunction<long>
    {
        private long Benefnumcarte { get; set; }
        public AjoutBenef(long numCarte)
        {
            InitializeComponent();

            Benefnumcarte = numCarte;
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Numero.Text, out int idtCompte))
            {
                if (SqlRequests.EstBeneficiairePotentiel(idtCompte))
                {
                    SqlRequests.AjouterBeneficiaire(Benefnumcarte, idtCompte);
                    OnReturn(null);
                }
                else
                {
                    MessageBox.Show("Saisie bénéficiaire invalide");
                }
            }
            else
            {
                MessageBox.Show("Numéro compte incorrect");
            }
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            OnReturn(null);
        }

        private void OnReturn(object p)
        {
            throw new NotImplementedException();
        }
    }
}

