using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using SQLite;

namespace StashApp
{
    class StashedProduct
    {
        [PrimaryKey, AutoIncrement]
        public int StashID { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
        [MaxLength(32)]
        public string Store { get; set; }
        public float Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
    class UPCListings
    {
        [PrimaryKey, AutoIncrement]
        public int UpcID { get; set; }
        [MaxLength(128)]
        public string ProductName { get; set; }
        public int UPC { get; set; }
    }
}
