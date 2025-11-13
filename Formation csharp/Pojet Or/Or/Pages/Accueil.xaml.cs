using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Or.Business;
using Or.Models;



namespace Or.Pages
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : Page
    {
        public Accueil()
        {
            InitializeComponent();
        }

        public void GoConsultationCarte(object sender, RoutedEventArgs e)
        {
            bool estCarteValide = long.TryParse(NumeroCarte.Text, out long result);

            if (estCarteValide)
            {
                var carte = SqlRequests.InfosCarte(result);

                // Debug lorsque le numero de carte n'existe pas dans la base de données SQL
                if (carte == null)
                {
                    MessageBox.Show("Numéro de carte non présent dans la base de données", "Carte inexistante", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                // Si la carte existe, on peut naviguer vers la page Consultation carte
                else
                {
                    NavigationService.Navigate(new ConsultationCarte(result));
                }
            }
            // Cas où le numéro de carte n'est pas valide (caractère autre que des chiffres)
            else
            {
                MessageBox.Show("Numéro de carte invalide", "Saisie invalide", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void CreerNouveauClient(object sender, RoutedEventArgs e)
        {
            string prenom = Prenom.Text;
            string nom = Nom.Text;
            int plafondMax = int.Parse(Plafond.Text);
            int idconseiller = int.Parse(IdConseiller.Text);

            try
            {
                var creation = SqlRequests.CreerClient(prenom, nom, plafondMax, idconseiller, idcompte);
                MessageBox.Show($"Compte crée ! Numéro de carte : {creation.numCarte} et compte courant : {idcompte}");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                BBBB
            }
        }


        public void GoMouse(object sender, RoutedEvent e)
        {

        }
    }
}
