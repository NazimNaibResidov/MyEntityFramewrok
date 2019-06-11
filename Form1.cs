
using EntityFrameworkMy.Model;
using System;
using System.Windows.Forms;

namespace EntityFrameworkMy.Wind.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataContext Context = new DataContext();
        private void Form1_Load(object sender, EventArgs e)
        {

         
            
            //DataContext context = new DataContext();
            //Image image = new Image();
            //image.Name = "fff";
            //context.Image.InsertWithProc(image);
            //context.Image.Delete(image);

         }

        private void button1_Click(object sender, EventArgs e)
        {
            DataContext context = new DataContext();
            Image image = new Image();
          
          //  context.Image.InsertWithProc(image);
            context.Image.Delete(x => x.Name=="fff");
        }
    }
}
