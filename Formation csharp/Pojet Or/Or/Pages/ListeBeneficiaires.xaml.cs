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
using Or.Pages;

namespace Or.Pages
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>

    public partial class ListeBeneficiaire : PageFunction<long>
    {
        private long Benefnumcarte { get; set; }

        public ListeBeneficiaire(long numCarte)
        {
            InitializeComponent();

            Benefnumcarte = numCarte;

            Carte c = SqlRequests.InfosCarte(numCarte);

            Numero.Text = c.Id.ToString();
            Prenom.Text = c.PrenomClient;
            Nom.Text = c.NomClient;

            listView.ItemsSource = SqlRequests.ListeBeneficiairesAssocieClient(numCarte);
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            PageFunctionNavigate(new AjoutBenef(Benefnumcarte));
        }

        private void PageFunctionNavigate(AjoutBenef ajoutBenef)
        {
            throw new NotImplementedException();
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            int idtCpt = (int)(sender as Button).CommandParameter;
            SqlRequests.SupprimerBeneficiaire(Benefnumcarte, idtCpt);
            listView.ItemsSource = SqlRequests.ListeBeneficiairesAssocieClient(Benefnumcarte);
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            OnReturn(null);
        }

        void PageFunctionNavigate(PageFunction<long> page)
        {
            page.Return += new ReturnEventHandler<long>(PageFunction_Return);
            NavigationService.Navigate(page);
        }

        void PageFunction_Return(object sender, ReturnEventArgs<long> e)
        {
            listView.ItemsSource = SqlRequests.ListeBeneficiairesAssocieClient(long.Parse(Numero.Text));
        }

        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            GridView gridView = listView.View as GridView;
            if (gridView != null)
            {
                double totalWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth;
                gridView.Columns[0].Width = totalWidth * 0.10; // 10%
                gridView.Columns[1].Width = totalWidth * 0.30; // 40%
                gridView.Columns[2].Width = totalWidth * 0.30; // 20%
                gridView.Columns[3].Width = totalWidth * 0.30; // 20%
            }
        }
    }
}
