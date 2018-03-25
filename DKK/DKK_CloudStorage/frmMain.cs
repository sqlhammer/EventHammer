using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Windows.Forms;
using System.Configuration;

namespace DKK_CloudStorage
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void LaunchWebsite(string URL)
        {
            System.Diagnostics.Process.Start(URL);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            txtStatus.Text = "Idle";
            Refresh();

            DialogResult result = openFileDialog1.ShowDialog(); 
            if (result == DialogResult.OK) 
            {
                string filename = Path.GetFileName(openFileDialog1.FileName);
                string filedir = Path.GetDirectoryName(openFileDialog1.FileName);
                try
                {
                    UploadToAzure(filedir, filename);
                }
                catch (IOException ex)
                {
                    txtStatus.Text = ex.Message;
                }
            }
        }

        private void UploadToAzure(string filedir, string filename)
        {
            string DefaultEndpointsProtocol = ConfigurationManager.AppSettings["DefaultEndpointsProtocol"];
            string AccountName = ConfigurationManager.AppSettings["AccountName"];
            string AccountKey = ConfigurationManager.AppSettings["AccountKey"];
            string EndpointSuffix = ConfigurationManager.AppSettings["EndpointSuffix"];
            string UploadFileName = ConfigurationManager.AppSettings["UploadFileName"];
            string containerName = ConfigurationManager.AppSettings["ContainerName"];

            string storageConnectionString = String.Format("DefaultEndpointsProtocol={0};"
                                            + "AccountName={1}"
                                            + ";AccountKey={2}"
                                            + ";EndpointSuffix={3}",
                                            DefaultEndpointsProtocol, AccountName, AccountKey, EndpointSuffix);
            
            txtStatus.Text = "Working";
            Refresh();

            CloudStorageAccount account = CloudStorageAccount.Parse(storageConnectionString);
            CloudBlobClient serviceClient = account.CreateCloudBlobClient();
            
            var container = serviceClient.GetContainerReference(containerName);
            
            CloudBlockBlob blob = container.GetBlockBlobReference(UploadFileName);
            using (var fileStream = File.OpenRead(Path.Combine(filedir, filename)))
            {
                try
                {
                    blob.UploadFromStream(fileStream);

                    txtStatus.Text = "Success";
                }
                catch (Exception ex)
                {
                    txtStatus.Text = ex.Message;
                }
            }
        }

        private void pbDKK_Click(object sender, EventArgs e)
        {
            LaunchWebsite("http://www.danburykarate.com");
        }

        private void pbPwredBy_Click(object sender, EventArgs e)
        {
            LaunchWebsite("https://www.sqlhammer.com");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtStatus.Text = "Idle";
        }
    }
}
