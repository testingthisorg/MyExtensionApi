using Newtonsoft.Json;

using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace Assassins.Helpers
{
    public static class AppSerializer
    {
        private static Regex rgxJsonId = new Regex(@"(\s)*json:id=""[0-9]+(\s)*""");
        private static Regex rgxUrl = new Regex(@"(\s)*xmlns:json=""http://james.newtonking.com/projects/json""(\s)*");
        public static string Xml(object project)
        {
            var json = Json(project);

            var xmlDoc = JsonConvert.DeserializeXmlNode(json, "Graph", false);
            var sw = new StringWriter();
            var xmlWr = new XmlTextWriter(sw)
            {
                Formatting = System.Xml.Formatting.Indented
            };
            xmlDoc.WriteTo(xmlWr);
            var xmlStr = sw.ToString();
            var xmlNorm = rgxJsonId.Replace(xmlStr, string.Empty);
            xmlNorm = rgxUrl.Replace(xmlNorm, string.Empty);
            return xmlNorm;
        }
        public static string Json(object project)
        {
            var toExport = JsonConvert.SerializeObject(project, new JsonSerializerSettings() {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Newtonsoft.Json.Formatting.Indented
            });
            return toExport;

        }
    }
}
