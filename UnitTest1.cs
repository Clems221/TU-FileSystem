using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileSystem;
using System.Collections.Generic;
using System.Linq;


namespace TU
{
    [TestClass]
    public class TU
    {

        public Directory current;
        public File NouvFile;

        public Directory Dossier1;
        public Directory Dossier2;
        public Directory Dossier3;
        public File CFile;




        [TestInitialize]
        public void SetUp()
        {
            current = new Directory("C:", true);
            current.chmod(7);
            current.mkdir("Dossier1");
            current.mkdir("Dossier2");
            current.mkdir("Dossier3");
            current.createNewFile("CFile");
            NouvFile = current.cd("NouvFile");
            Dossier1 = (Directory)current.cd("Dossier1");
            Dossier2 = (Directory)current.cd("Dossier2");
            Dossier3 = (Directory)current.cd("Dossier3");


            CFile = current.cd("CFile");
            Dossier2 = (Directory)current.cd("Dossier2");
        }


        [TestMethod]
        public void cd()
        {
            File recup = current.cd("Dossier1");
            Assert.AreEqual(recup.Name, "Dossier1");
        }


        [TestMethod]
        public void ls()
        {
            List<File> listels = current.ls();
            Assert.AreEqual(listels.Count(), 4);
        }
        [TestMethod]
        public void mkdir()
        {
            Assert.IsTrue(current.mkdir("Essai"));
        }
        [TestMethod]
        public void mkdirNoWrite()
        {
            current.chmod(1);
            Assert.IsFalse(current.mkdir("Essai"));
        }

        [TestMethod]
        public void mkdirNoRead()
        {
            current.chmod(4);
            Assert.IsFalse(current.mkdir("Essai"));
        }

        [TestMethod]
        public void ChmodExec()
        {
            Dossier2.chmod(1);
            Assert.IsTrue(Dossier2.canExecute());
        }

        [TestMethod]
        public void ChmodWrite()
        {
            Dossier2.chmod(2);
            Assert.IsTrue(Dossier2.canWrite());
        }

        [TestMethod]
        public void ChmodRead()
        {
            Dossier2.chmod(4);
            Assert.IsTrue(Dossier2.canRead());
        }

        [TestMethod]
        public void ChmodAll()
        {
            Dossier2.chmod(7);
            Assert.IsTrue(Dossier2.canWrite());
            Assert.IsTrue(Dossier2.canExecute());
            Assert.IsTrue(Dossier2.canRead());
        }


        [TestMethod]
        public void CreateNewFile()
        {

            Assert.IsTrue(current.createNewFile("Test"));
        }
        [TestMethod]
        public void CreateNewFileNoWrite()
        {
            current.chmod(1);
            Assert.IsFalse(current.createNewFile("Test"));
        }
        /*[TestMethod]
        public void CreateNewFileExistant()
        {
            Assert.IsTrue(current.createNewFile("Dossier2"));
        }*/



        [TestMethod]
        public void delete()
        {
            bool fichier = current.delete("Dossier1");
            Assert.IsTrue(fichier, "Dossier1");
        }

        [TestMethod]
        public void renameTo()
        {
            Assert.IsTrue(current.renameTo("NouveauDossier1", "test"));
        }
        [TestMethod]
        public void IsFile()
        {
            Assert.IsFalse(Dossier2.isFile());
        }

        [TestMethod]
        public void IsDirectory()
        {
            Assert.IsFalse(CFile.isDirectory());
        }
        [TestMethod]
        public void search()
        {
            File recherche = current.cd("Dossier1");
            Assert.AreEqual(recherche.Name, "Dossier1");
        }

        [TestMethod]
        public void getRoot()
        {

            Directory Essai = (Directory)current.cd("Dossier1");
            Essai.chmod(7);
            Essai.mkdir("Dossier2");
            Directory Essai2 = (Directory)Essai.cd("Dossier2");
            Assert.AreEqual(Essai2.getRoot().getName(), "Dossier1");
        }


        [TestMethod]
        public void getParent()
        {
            Directory Essai = (Directory)current.cd("Dossier1");
            Essai.chmod(7);
            Essai.mkdir("Dossier2");
            Directory Essai2 = (Directory)Essai.cd("Dossier2");
            Essai2.cd("Dossier1");
            Assert.AreEqual(Essai2.getParent().getName(), "Dossier1");
        }
        [TestMethod]
        public void getName()
        {
            Directory Essai = (Directory)current.cd("Dossier1");
            Essai.chmod(4);
            Assert.AreEqual(Essai.getName(), "Dossier1");
        }

        [TestMethod]
        public void getName1()
        {
            Directory Essai = (Directory)current.cd("Dossier1");
            Essai.chmod(1);
            Assert.AreNotEqual(Essai.getName(), "Dossier1");
        }

        [TestMethod]
        public void getName2()
        {
            Directory Essai = (Directory)current.cd("Dossier1");
            Essai.chmod(2);
            Assert.AreNotEqual(Essai.getName(), "Dossier1");
        }

        [TestMethod]
        public void getPath()
        {
            Directory Essai = (Directory)current.cd("Dossier1");
            Essai.chmod(7);
            Essai.mkdir("Dossier2");
            Directory Essai2 = (Directory)Essai.cd("Dossier2");

            Assert.AreEqual(Essai2.getPath(), "C:/Dossier1/Dossier2");
        }


        [TestMethod]
        public void getPermission()
        {
            Directory Essai = (Directory)current.cd("Dossier1");
            Essai.chmod(7);
            Assert.AreEqual(Essai.getPermission(), 7);
        }
        [TestMethod]
        public void getPermission1()
        {
            Directory Essai = (Directory)current.cd("Dossier1");
            Essai.chmod(2);
            Assert.AreNotEqual(Essai.getPermission(), 7);
        }




    }
}
