using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;

/*
 * bitclean: Manager.cs
 * Author: Austin Herman
 * 4/12/2019
 * Manages file directories/path meta data for user
 */

namespace BitClean
{
	public class Manager
	{
		private string imgDirectory = "", xmlDirectory = "", imgPath = "", xmlPath = "", executablePath = "";

		public string ImageDirectory {	get => imgDirectory; set => imgDirectory = value; } // directory of the image
		public string XMLDirectory	{	get => xmlDirectory; set => xmlDirectory = value; } // directory of the xml data

		public string ImagePath { get => imgPath; set => imgPath = value; } // full path name of image		-- not saved in meta data file
		public string XMLPath	{ get => xmlPath; set => xmlPath = value; }	// full path name of xml data	-- not saved in meta data file
		public string ExecutablePath { get => executablePath; set => executablePath = value; }	// program's executable directory

		public Manager()
		{
			// get exe path
			executablePath = Path.GetDirectoryName(Application.ExecutablePath);

			// get xml file with the image and xml directory data
			XElement doc = XDocument.Load(executablePath + Constants.META_DATA_PATH + Constants.META_PATHS).Root;
			imgDirectory = (string)doc.Attribute("bmp_image");
			xmlDirectory = (string)doc.Attribute("xml_data");

			// if no meta data, set default to exe path
			if (imgDirectory == "") imgDirectory = executablePath;
			if (xmlDirectory == "") xmlDirectory = executablePath;

		}

		public void SetImageDirectory(string dir)
		{
			// set the image directory, store in meta data file
			imgDirectory = dir;
			XElement doc = XDocument.Load(executablePath + Constants.META_DATA_PATH + Constants.META_PATHS).Root;
			doc.SetAttributeValue("bmp_image", imgDirectory);

			Console.WriteLine(doc);

			doc.Save(executablePath + Constants.META_DATA_PATH + Constants.META_PATHS);
		}
		public void SetXMLDirectory(string dir)
		{
			// set the xml directory, store in meta data file
			xmlDirectory = dir;
			XElement doc = XDocument.Load(executablePath + Constants.META_DATA_PATH + Constants.META_PATHS).Root;
			doc.SetAttributeValue("xml_data", xmlDirectory);

			Console.WriteLine(doc);

			doc.Save(executablePath + Constants.META_DATA_PATH + Constants.META_PATHS);
		}

	}
}
