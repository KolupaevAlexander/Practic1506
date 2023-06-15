using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание_2
{
    public partial class Form1 :Form
    {
        public Form1 ()
        {
            InitializeComponent();
        }

        //Задание 2
        Shop pyaterochka = new Shop();
        private void addProduct_Click (object sender, EventArgs e)
        {
            if (productName.Text != "" && price.Value != 0 && addProductCount.Value != 0)
            {
                Product product = new Product(productName.Text, price.Value);
                pyaterochka.AddProduct(product, (int) addProductCount.Value);
                ShowShopList();
                //ShopList.Items.Add($"{product.Name} {(int) addProductCount.Value}шт.");
            }
        }
        private void ShowShopList()
        {
            ShopList.Items.Clear();
            ShopList.Items.AddRange(pyaterochka.Producs.Keys.Select(x=>$"{x.Name} {x.Price} руб. {pyaterochka.Producs[x]} шт.").ToArray());
            Money.Text = $"Счет: {pyaterochka.Money}";
        }
        private void sell_Click (object sender, EventArgs e)
        {
            if (sellingProduct.Text != "" && sellingCount.Value != 0)
            { 
                pyaterochka.Sell(sellingProduct.Text, (int)sellingCount.Value);

                ShowShopList();
            }
        }

        //Задание 3
        Playlist playlist = new Playlist();
        private void addSong_Click (object sender, EventArgs e)
        {
            if (authorName.Text != "" && songName.Text != "" && pathOfSong.Text != "")
                playlist.Addsong(authorName.Text, songName.Text, pathOfSong.Text);
            else
                MessageBox.Show("Некорректный ввод");

            ShowPlaylist();
        }

        public void ShowPlaylist()
        {
            PlaylistShow.Items.Clear();
            PlaylistShow.Items.AddRange(playlist.List.Select(x=>$"{x.Author} {x.Title}").ToArray());
        }

    }
}
