using Carteira.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carteira.Utility
{
    public static class TemplateLeomar
    {
        public static int _countLine { get; set; }
        //HTML
        public static string _InitHtml = @"<html> 

            <body>";
        public static string _EndHtml = " </body> </html> ";

        //PAGE
        public static string _startPage = "<div class='page'>";
        public static string _endPage = "</div>";

        //HEADER E FOOTER
        public static string _header = "<div class='header'> Cabeçalho </div>";
        public static string _footer = "<div class='footer'> Rodapé </div>";

        //CORPO
        public static string _startBody = "<div class='body'>";
        public static string _endBody = "</div>";

        //LINHA
        public static string _startLine = " <div class='linha'>";
        public static string _endLine = "</div>";

        public static string GeneratePDF(List<Employee> empregados)
        {
            _countLine = 0;
            int countTotal = 0;
            int countFinal = empregados.Count();


            var builders = new List<StringBuilder>();

            var sb = new StringBuilder();
           

            foreach (var empregado in empregados)
            {
                
                if (_countLine == 0)
                {
                    sb.Append(_startPage);

                    sb.Append(_header);

                    sb.Append(_startBody);
                }

                sb.Append(_startLine);

                sb.AppendFormat(@"{0}", empregado.Name);

                sb.Append(_endLine);

                _countLine++;
                countTotal++;

                if (_countLine == 34 || countTotal == countFinal)
                {
                    sb.Append(_endBody);

                    sb.Append(_footer);

                    sb.Append(_endPage);

                    if(!(countTotal == countFinal))
                        sb.Append("<div class='quebra-pagina'></div>");

                    builders.Add(sb);

                    sb = new StringBuilder();

                    _countLine = 0;
                }
            }

            return montarHTML(builders);
        }

        public static string addLine()
        {
            return "";
        }

        public static string montarHTML(List<StringBuilder> conteudo)
        {
            var sb = new StringBuilder();

            sb.Append(_InitHtml);

            foreach (var pagina in conteudo)
            {
                sb.Append(pagina.ToString());
            }

            sb.Append(_EndHtml);

            var res =  sb.ToString();

            return res;
        }
    }
}
