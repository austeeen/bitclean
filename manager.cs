using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;

namespace BitClean
{
	public class Manager
	{
		private string executablePath = "", imgDirectory = "", xmlDirectory = "";

		public string ImageDirectory => imgDirectory;
		public string XMLDirectory => xmlDirectory;
		public string ExecutablePath => executablePath;

		public Manager()
		{
			executablePath = Path.GetDirectoryName(Application.ExecutablePath);

			XElement doc = XDocument.Load(executablePath + Constants.META_DATA_PATH + Constants.META_PATHS).Root;
			imgDirectory = (string)doc.Attribute("bmp_image");
			xmlDirectory = (string)doc.Attribute("xml_data");

			if (imgDirectory == "") imgDirectory = executablePath;
			if (xmlDirectory == "") xmlDirectory = executablePath;

		}

		public void SetImageDirectory(string path)
		{
			imgDirectory = path;
			XElement doc = XDocument.Load(executablePath + Constants.META_DATA_PATH + Constants.META_PATHS).Root;
			doc.SetAttributeValue("bmp_image", imgDirectory);

			Console.WriteLine(doc);

			doc.Save(executablePath + Constants.META_DATA_PATH + Constants.META_PATHS);
		}
		public void SetXMLDirectory(string path)
		{
			xmlDirectory = path;
			XElement doc = XDocument.Load(executablePath + Constants.META_DATA_PATH + Constants.META_PATHS).Root;
			doc.SetAttributeValue("xml_data", xmlDirectory);

			Console.WriteLine(doc);

			doc.Save(executablePath + Constants.META_DATA_PATH + Constants.META_PATHS);
		}

	}
}
