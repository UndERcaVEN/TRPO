using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.ServiceModel.Web;

namespace JSON
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tovar tovar1 = new Tovar(10, "Стол", 4500);
            label1.Text = string.Format("код={0}\n наименование={1} \n price ={2} ", tovar1.ID,tovar1.Name,tovar1.Price );
           
            System.Runtime.Serialization.Json.DataContractJsonSerializer ps = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(Tovar));
            
           
            System.IO.Stream memory = new System.IO.MemoryStream();

            ps.WriteObject(memory, tovar1);
            memory.Position = 0;
            System.IO.StreamReader ReadMemory = new System.IO.StreamReader(memory);
            string s = ReadMemory.ReadToEnd();
            textBox1.Text = s;
            // Десериализация строки в объект
            string s1  = "{\"код\":11,\"наименование\":\"Стул\",\"цена\":500}";
            System.IO.Stream stream = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(s1));
            label1.Text += string.Format("\n n={0}", stream.Length);
            Tovar tov2 = (Tovar)ps.ReadObject(stream);
            label1.Text += string.Format("\n код={0}\n наименование={1} \n цена ={2}    ", tov2.ID, tov2.Name, tov2.Price);
 }
    }

}
