using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text.RegularExpressions;

namespace SmartTemplateProcessor
{
    public static class Processor
    {
        /// <summary>
        /// Processa o template com o objeto de contexto.
        /// Para processar o template usar {{PropriedadeDoObjetoDeContexto}}
        /// É possível acessar propriedades de objetos dentro do objeto através do . usando
        /// {{PropriedadeDoObjetoDeContexto.PropriedadeDoProximoObjeto}}
        /// </summary>
        /// <param name="template">Template para ser processado.</param>
        /// <param name="contextObj">Objeto de contexto que contém as propriedades que serão substituídas no template.</param>
        /// <returns>Template processado com o objeto de contexto.</returns>
        public static string ProcessTemplate(string template, object contextObj)
        {
            if (string.IsNullOrEmpty(template) || contextObj == null)
            {
                return string.Empty;
            }

            JObject contextObjJson = JObject.FromObject(contextObj ?? new object());

            return Regex.Replace(template, @"\{\{([\w\.]+)\}\}", delegate (Match match)
            {
                string group = match.Groups[1].ToString();

                var value = group
                    .Split('.')
                    .Aggregate((object)contextObjJson, (a, b) =>
                    {
                        var jObj = (JObject.Parse(a.ToString())) ?? a as JToken;

                        if (jObj != null)
                        {
                            return jObj[b];
                        }

                        return null;
                    });

                return value != null ? (value.ToString()) : string.Empty;
            });
        }
    }
}
