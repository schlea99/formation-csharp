﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml.Serialization;


namespace Or.Models
{
    // Projet Or - Partie 2 : Sérialisation XML
    [XmlRoot("Compte")]
    public class ExportCompte
    {
        [XmlElement("Identifiant")]
        public int Id { get; set; }

        [XmlElement("Type")]
        public TypeCompte TypeDuCompte { get; set; }

        [XmlElement("Solde")]
        public string Solde { get; set; }

        [XmlArray("Transactions")]
        [XmlArrayItem("Transaction")]
        public List<ExportCompteTransactions> Historique { get; set; }
    }

    public class ExportCompteTransactions
    {
        [XmlElement("Identifiant")]
        public int IdTransaction { get; set; }

        [XmlElement("Date")]
        public string Horodatage { get; set; }

        [XmlElement("Montant")]
        public string Montant { get; set; }

        [XmlElement("CompteExpediteur")]
        public string Expediteur { get; set; }

        [XmlElement("CompteDestinataire")]
        public string Destinataire { get; set; }

        [XmlElement("Operation")]
        public string Type { get; set; }

    }



}
