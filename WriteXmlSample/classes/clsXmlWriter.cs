using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WriteXmlSample
{
    internal class clsXmlWriter
    {


        private class clsTestData
        {
            public string name = string.Empty;
            public int age = 0;
            public string gender = string.Empty;
        }


        private List<clsTestData> mylist = new List<clsTestData>() {
                                                new clsTestData { name = "ichiro", age = 23, gender = "male" },
                                                new clsTestData { name = "jiro", age = 25, gender = "male" },
                                                new clsTestData { name = "hanako", age = 21, gender = "female" }
                                            };

        public bool WriteXml(string strFilePath)
        {
            try
            {
                // xmlドキュメントの生成
                XDocument xml_doc = new XDocument();

                xml_doc.Declaration = new XDeclaration("1.0", "utf-8", "true");

                // xmlに出力するコンテンツを生成
                XElement root = new XElement("ArrayOfUserinfo");

                foreach (clsTestData user in mylist)
                {
                    XElement section = new XElement("Userinfo",
                                            new XElement("name", user.name),
                                            new XElement("age", user.age),
                                            new XElement("gender", user.gender)
                                            );
                    root.Add(section);
                }

                // xmlドキュメントにコンテンツを追加
                xml_doc.Add(root);

                // XMLファイルに書込み
                xml_doc.Save(strFilePath);

                // 書き込み結果は下記を参照

                //  <?xml version="1.0" encoding="utf-8"?>
                //  <ArrayOfUserinfo>
                //    <Userinfo>
                //      <name>ichiro</name>
                //      <age>23</age>
                //      <gender>male</gender>
                //    </Userinfo>
                //    <Userinfo>
                //      <name>jiro</name>
                //      <age>25</age>
                //      <gender>male</gender>
                //    </Userinfo>
                //    <Userinfo>
                //      <name>hanako</name>
                //      <age>21</age>
                //      <gender>female</gender>
                //    </Userinfo>
                //  </ArrayOfUserinfo>

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
