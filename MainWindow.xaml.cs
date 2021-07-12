using PrintApp.Data;
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
using PrintApp.Model;
using System.IO;

namespace PrintApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int OpenedForm = 1;

        public static IDictionary<string, string> ButtonContents;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void load_Loaded(object sender, RoutedEventArgs e)
        {
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);

            ButtonContents = new Dictionary<string, string>
            {
                { "Button1", "برگه استشهادیه" },
                { "Button2", "برگه دادخواست تجدیدنظر" },
                { "Button3", "برگه دادخواست نخستین" },
                {"Button4","برگه استشهادیه محلی" },
                {"Button5","برگه ارزش منطقه ای" },
                {"Button6","برگه شکوائیه" },
                {"Button7","" },
                {"Button8","" },
                {"Button9","برگه درخواست کفالت" },
                {"Button10","" },
                {"Button11","" },
                {"Button12","" },
                {"Button13","" },
                {"Button14","" },
                {"Button15","" },
                {"Button16","" },
                {"Button17","" },
                {"Button18","" },
                {"Button19","" },
                {"Button20","" },
                {"Button21","" },
            };

            btn1.Content = ButtonContents["Button1"];
            btn2.Content = ButtonContents["Button2"];
            btn3.Content = ButtonContents["Button3"];

            btn4.Content = ButtonContents["Button4"];
            btn5.Content = ButtonContents["Button5"];
            btn6.Content = ButtonContents["Button6"];

            btn7.Content = ButtonContents["Button7"];
            btn8.Content = ButtonContents["Button8"];
            btn9.Content = ButtonContents["Button9"];

            btn10.Content = ButtonContents["Button10"];
            btn11.Content = ButtonContents["Button11"];
            btn12.Content = ButtonContents["Button12"];

            btn13.Content = ButtonContents["Button13"];
            btn14.Content = ButtonContents["Button14"];
            btn15.Content = ButtonContents["Button15"];

            btn16.Content = ButtonContents["Button16"];
            btn17.Content = ButtonContents["Button17"];
            btn18.Content = ButtonContents["Button18"];

            btn19.Content = ButtonContents["Button19"];
            btn20.Content = ButtonContents["Button20"];
            btn21.Content = ButtonContents["Button21"];



            //byte[] bArr = imgToByteConverter(img);
            //Again convert byteArray to image and displayed in a picturebox
            //Image img1 = byteArrayToImage(bArr);
            // pictureBox1.Image = img1;

            try
            {
                using (var context = new AppDbContext())
                {
                    // Object rm = Properties.Resources.ResourceManager.GetObject("image1");
                    //Bitmap myImage = (Bitmap)rm;
                    //System.Drawing.Image image = myImage;
                    //image to byteArray
                    //  System.Drawing.Image img = System.Drawing.Image.FromFile(nameof(Properties.Resources.image1));
                    //  byte[] bimg = ImageToByteArray();

                    // context.Database.EnsureCreated();



                    var pageinfos = new List<Pageinfo> {






                    new Pageinfo { PageName ="برگه استشهادیه",  FormName="عکس برگه استشهادیه", OnePagePrice = 4000  }

        };
                    if (context.Pageinfoes.Any())
                    {
                        //  MessageBox.Show("دیتابیس موجود است.");
                        //  var page = new Page { PageName = "برگه دادخواست نخستین", PictureName = "عکس برگه دادخواست نخستین", OnePagePrice = 3500, Picture = BitmapToByteArray(Properties.Resources.puppy) };



                        // context.Pages.Add(page);
                        //context.SaveChanges();
                    }
                    else
                    {
                        context.Pageinfoes.AddRange(pageinfos);
                        context.SaveChanges();

                    }


                    //  dataGridView1.DataSource = authors;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }
        public BitmapImage String64ToImageSource(string bgImage64)
        {

            byte[] binaryData = Convert.FromBase64String(bgImage64);

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = new MemoryStream(binaryData);
            bi.EndInit();
            return bi;





        }


        public void FillPageByPageIdAndShow(int id)
        {
            FormShow formShow = new FormShow();
            using (var context = new AppDbContext())
            {
                var item = context.Pageinfoes.Where(i => i.Id == id).SingleOrDefault();

                formShow.lblPictureName.Content = (item == null) ? "فرم شماره "+ OpenedForm.ToString() : item.FormName.ToString(); //.Select(i => i.PictureName);
                formShow.lblPagePrice.Content = (item == null) ? "۱۰۰۰ "+"نومان" : item.OnePagePrice.ToString()+" "+ "نومان"; //.Select(i => i.OnePagePrice).ToString();
                                                                                                //  secondaryWindow.imgPage.Source = ByteImageConverter.ByteToImage(item.Picture); //.Select(i => i.Picture);
              //  secondaryWindow.imgPage.Source = String64ToImageSource(ImagesString64.Images[id]);

            }
            OpenedForm = id;
            formShow.ShowDialog();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillPageByPageIdAndShow(1);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillPageByPageIdAndShow(2);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillPageByPageIdAndShow(3);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillPageByPageIdAndShow(4);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillPageByPageIdAndShow(5);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillPageByPageIdAndShow(6);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillPageByPageIdAndShow(7);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillPageByPageIdAndShow(8);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillPageByPageIdAndShow(9);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn10_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillPageByPageIdAndShow(10);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn11_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillPageByPageIdAndShow(11);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn12_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillPageByPageIdAndShow(12);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn13_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillPageByPageIdAndShow(13);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn14_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillPageByPageIdAndShow(14);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn15_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillPageByPageIdAndShow(15);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn16_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillPageByPageIdAndShow(16);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn17_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillPageByPageIdAndShow(17);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn18_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillPageByPageIdAndShow(18);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn19_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillPageByPageIdAndShow(19);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn20_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillPageByPageIdAndShow(20);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn21_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillPageByPageIdAndShow(21);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Convert Image File to Base64 String
        //    public void convert1()
        //    {
        //        byte[] fileContent = FileUtils.readFileToByteArray(new File(""));
        //    String encodedString = Base64.getEncoder().encodeToString(fileContent);
        //}
        //Convert Base64 String to Image 
        // public void convert1()
        //    {
        // byte[] decodedBytes = Base64.getDecoder().decode(encodedString);
        // FileUtils.writeByteArrayToFile(new File(outputFileName), decodedBytes);
        //}

        //public static byte[] BitmapToByteArray(Bitmap bitmap)
        //{

        //    BitmapData bmpdata = null;

        //    try
        //    {
        //        bmpdata = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
        //        int numbytes = bmpdata.Stride * bitmap.Height;
        //        byte[] bytedata = new byte[numbytes];
        //        IntPtr ptr = bmpdata.Scan0;

        //        Marshal.Copy(ptr, bytedata, 0, numbytes);

        //        return bytedata;
        //    }
        //    finally
        //    {
        //        if (bmpdata != null)
        //            bitmap.UnlockBits(bmpdata);
        //    }

        //}

        //public byte[] imageToByteArray(System.Drawing.Image imageIn)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        //    return ms.ToArray();
        //}

        //public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    MemoryStream ms = new MemoryStream(byteArrayIn);
        //    System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
        //    return returnImage;
        //}

        //public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        imageIn.Save(ms, imageIn.RawFormat);
        //        return ms.ToArray();
        //    }
        //}

        //public static byte[] converterDemo(System.Drawing.Image x)
        //{
        //    ImageConverter _imageConverter = new ImageConverter();
        //    byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
        //    return xByte;
        //}

        //public static Bitmap GetImageFromByteArray(byte[] byteArray)
        //{
        //    ImageConverter _imageConverter = new ImageConverter();

        //    Bitmap bm = (Bitmap)_imageConverter.ConvertFrom(byteArray);

        //    if (bm != null && (bm.HorizontalResolution != (int)bm.HorizontalResolution ||
        //                       bm.VerticalResolution != (int)bm.VerticalResolution))
        //    {
        //        // Correct a strange glitch that has been observed in the test program when converting 
        //        //  from a PNG file image created by CopyImageToByteArray() - the dpi value "drifts" 
        //        //  slightly away from the nominal integer value
        //        bm.SetResolution((int)(bm.HorizontalResolution + 0.5f),
        //                         (int)(bm.VerticalResolution + 0.5f));
        //    }

        //    return bm;
        //}

        //// Bitmap newBitmap = GetImageFromByteArray(File.ReadAllBytes(fileName));

        ////Global field
        //BitmapImage BM;
        ////Convert image to bytes by following method
        //private static byte[] ImageToBytes(BitmapImage image)
        //{
        //    byte[] Data;
        //    JpegBitmapEncoder JpegEncoder = new JpegBitmapEncoder();
        //    JpegEncoder.Frames.Add(BitmapFrame.Create(image));
        //    using (System.IO.MemoryStream MS = new System.IO.MemoryStream())
        //    {
        //        JpegEncoder.Save(MS);
        //        Data = MS.ToArray();
        //    }
        //    return Data;
        //}

        //public class ByteImageConverter
        //{
        //    public static ImageSource ByteToImage(byte[] imageData)
        //    {

        //        //  BitmapImage biImg = new BitmapImage();
        //        var bitmap = new BitmapImage();

        //        using (var stream = new MemoryStream(imageData))
        //        {
        //            bitmap.BeginInit();
        //            bitmap.StreamSource = stream;
        //            bitmap.CacheOption = BitmapCacheOption.OnLoad;
        //            bitmap.EndInit();
        //            bitmap.Freeze();
        //        }

        //        //using (MemoryStream ms = new MemoryStream(imageData))
        //        //{
        //        //    // ...
        //        //    biImg.BeginInit();
        //        //    biImg.StreamSource = ms;
        //        //    biImg.EndInit();

        //        //}

        //        // MemoryStream ms = new MemoryStream(imageData);

        //        ImageSource imgSrc = bitmap as ImageSource;

        //        return imgSrc;
        //    }
        //}





    }
}
