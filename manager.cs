using System;
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
        public string ImageDirectory { get; set; } = ""; // directory of the image
        public string XMLDirectory { get; set; } = ""; // directory of the xml data

        public string ImagePath { get; set; } = ""; // full path name of image		-- not saved in meta data file
        public string XMLPath { get; set; } = "";   // full path name of xml data	-- not saved in meta data file
        public string ExecutablePath { get; set; }  = "";   // program's executable directory

        public Manager()
		{
            // get exe path
            ExecutablePath = Path.GetDirectoryName(Application.ExecutablePath);

			// get xml file with the image and xml directory data
			XElement doc = XDocument.Load(ExecutablePath + Constants.META_DATA_PATH + Constants.META_PATHS).Root;
            ImageDirectory = (string)doc.Attribute("bmp_image");
            XMLDirectory = (string)doc.Attribute("xml_data");

			// if no meta data, set default to exe path
			if (ImageDirectory == "") ImageDirectory = ExecutablePath;
			if (XMLDirectory == "") XMLDirectory = ExecutablePath;

		}

		public void SetImageDirectory(string dir)
		{
            // set the image directory, store in meta data file
            ImageDirectory = dir;
			XElement doc = XDocument.Load(ExecutablePath + Constants.META_DATA_PATH + Constants.META_PATHS).Root;
			doc.SetAttributeValue("bmp_image", ImageDirectory);

			Console.WriteLine(doc);

			doc.Save(ExecutablePath + Constants.META_DATA_PATH + Constants.META_PATHS);
		}

		public void SetXMLDirectory(string dir)
		{
            // set the xml directory, store in meta data file
            XMLDirectory = dir;
			XElement doc = XDocument.Load(ExecutablePath + Constants.META_DATA_PATH + Constants.META_PATHS).Root;
			doc.SetAttributeValue("xml_data", XMLDirectory);

			Console.WriteLine(doc);

			doc.Save(ExecutablePath + Constants.META_DATA_PATH + Constants.META_PATHS);
		}

	}
}
