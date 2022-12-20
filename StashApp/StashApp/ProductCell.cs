using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace StashApp
{
    public class ProductCell : TextCell
    {
        public static readonly BindableProperty NameProperty = BindableProperty.Create("Name", typeof(string), typeof(ProductCell), default(string));
        public static readonly BindableProperty StoreProperty = BindableProperty.Create("Store", typeof(string), typeof(ProductCell), default(string));
        public static readonly BindableProperty PriceProperty = BindableProperty.Create("Price", typeof(string), typeof(ProductCell), default(string));
        public static readonly BindableProperty QuantityProperty = BindableProperty.Create("Quantity", typeof(string), typeof(ProductCell), default(string));
        public static readonly BindableProperty PurchaseDateProperty = BindableProperty.Create("PurchaseDate", typeof(string), typeof(ProductCell), default(string));
        public static readonly BindableProperty ExpirationDateProperty = BindableProperty.Create("ExpirationDate", typeof(string), typeof(ProductCell), default(string));

        public static readonly BindableProperty NameColorProperty = BindableProperty.Create("NameColor", typeof(Color), typeof(ProductCell), Color.Default);
        public static readonly BindableProperty StoreColorProperty = BindableProperty.Create("StoreColor", typeof(Color), typeof(ProductCell), Color.Default);
        public static readonly BindableProperty PriceColorProperty = BindableProperty.Create("PriceColor", typeof(Color), typeof(ProductCell), Color.Default);
        public static readonly BindableProperty QuantityColorProperty = BindableProperty.Create("QuantityColor", typeof(Color), typeof(ProductCell), Color.Default);
        public static readonly BindableProperty PurchaseDateColorProperty = BindableProperty.Create("PurchaseDateColor", typeof(Color), typeof(ProductCell), Color.Default);
        public static readonly BindableProperty ExpirationDateColorProperty = BindableProperty.Create("ExpirationDateColor", typeof(Color), typeof(ProductCell), Color.Default);

        public string Name
        {
            get { return (string)GetValue(DetailProperty); }
            set { SetValue(DetailProperty, value); }
        }
        public Color NameColor
        {
            get { return (Color)GetValue(DetailColorProperty); }
            set { SetValue(DetailColorProperty, value); }
        }
        public string Store
        {
            get { return (string)GetValue(DetailProperty); }
            set { SetValue(DetailProperty, value); }
        }
        public Color StoreColor
        {
            get { return (Color)GetValue(DetailColorProperty); }
            set { SetValue(DetailColorProperty, value); }
        }
        public string Price
        {
            get { return (string)GetValue(DetailProperty); }
            set { SetValue(DetailProperty, value); }
        }
        public Color PriceColor
        {
            get { return (Color)GetValue(DetailColorProperty); }
            set { SetValue(DetailColorProperty, value); }
        }
        public string Quantity
        {
            get { return (string)GetValue(DetailProperty); }
            set { SetValue(DetailProperty, value); }
        }
        public Color QuantityColor
        {
            get { return (Color)GetValue(DetailColorProperty); }
            set { SetValue(DetailColorProperty, value); }
        }
        public string PurchaseDate
        {
            get { return (string)GetValue(DetailProperty); }
            set { SetValue(DetailProperty, value); }
        }
        public Color PurchaseDateColor
        {
            get { return (Color)GetValue(DetailColorProperty); }
            set { SetValue(DetailColorProperty, value); }
        }
        public string ExpirationDate
        {
            get { return (string)GetValue(DetailProperty); }
            set { SetValue(DetailProperty, value); }
        }
        public Color ExpirationDateColor
        {
            get { return (Color)GetValue(DetailColorProperty); }
            set { SetValue(DetailColorProperty, value); }
        }
    }
}