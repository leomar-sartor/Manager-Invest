using Carteira.Models;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carteira.Utility
{
    //https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/static-constructors

    public class RelatorioTemplate
    {
        public int _linesPerPage = 0;
        public int Width { get; set; } = 2470;
        public int Height { get; set; } = 2230;
        public string _style = "";

        private StringBuilder _sb_classLine = new StringBuilder(".linha");
        private StringBuilder _sb_classPage = new StringBuilder(".page");
        private StringBuilder _sb_classHeader = new StringBuilder(".header");
        private StringBuilder _sb_classBody = new StringBuilder(".body");
        private StringBuilder _sb_classFooter = new StringBuilder(".footer");
        public string _styleLine = "";
        public string _stylePage = "";
        public string _styleHeader = "";
        public string _styleBody = "";
        public string _styleFooter = "";
        public string _styleQuebraPagina = @".quebra-pagina {" +
                                            " page-break-after: always;" +
                                            " background-color: darkgray;" +
                                            "}";

        #region HTML
        public int _countLine { get; set; }
        //HTML
        public string _InitHtml = @"<html> --style--

            <body>";
        public string _EndHtml = " </body> </html> ";

        //PAGE
        public string _startPage = "<div class='page'>";
        public string _endPage = "</div>";

        //HEADER E FOOTER
        public string _header = "<div class='header'> Cabeçalho </div>";
        public string _footer = "<div class='footer'> Rodapé </div>";

        //CORPO
        public string _startBody = "<div class='body'>";
        public string _endBody = "</div>";

        //LINHA
        public string _startLine = " <div class='linha'>";
        public string _endLine = "</div>";
        #endregion


        private StringBuilder _sb = new StringBuilder();

        public RelatorioTemplate()
        {
            Header = new Header();
            Body = new Body();
            Footer = new Footer();
            //_style = BuildStyle();
        }

        public Header Header { get; set; }
        public Body Body { get; set; }
        public Footer Footer { get; set; }

        public string BuildStyle()
        {
            BuildStylePage();
            BuildStyleHeader();
            BuildStyleLine();
            BuildStyleBody();
            BuildStyleFooter();

            var sb = new StringBuilder();

            sb.Append("<style>");
            sb.Append(_stylePage);
            sb.Append(_styleHeader);
            sb.Append(_styleBody);
            sb.Append(_styleLine);
            sb.Append(_styleFooter);
            sb.Append(_styleQuebraPagina);
            sb.Append("</style>");

            return sb.ToString();
        }

        public void BuildStylePage()
        {
            _sb_classPage.AppendLine(" {");
            _sb_classPage.AppendLine($" width: {Width}px;");
            _sb_classPage.AppendLine($" height: {Height}px;");
            _sb_classPage.AppendLine($" background-color: cadetblue;");
            _sb_classPage.AppendLine($" padding: 0;");
            _sb_classPage.AppendLine($" margin: 0;");
            _sb_classPage.AppendLine("}");

            _stylePage = _sb_classPage.ToString();
        }

        public void BuildStyleHeader()
        {
            _sb_classHeader.AppendLine(" {");
            _sb_classHeader.AppendLine($" width: {Header.Width}px;");
            _sb_classHeader.AppendLine($" height: {Header.Height}px;");
            _sb_classHeader.AppendLine($" background-color: chocolate;");
            _sb_classHeader.AppendLine("}");

            _styleHeader = _sb_classHeader.ToString();
        }

        public void BuildStyleLine()
        {
            _linesPerPage = Body.Height / (Body.FontSize + 2);
            var AlturaDaLinha = Body.FontSize + 2;

            _sb_classLine.AppendLine(" {");
            _sb_classLine.AppendLine($" width: {Width}px;");
            _sb_classLine.AppendLine($" height: {AlturaDaLinha}px;");
            _sb_classLine.AppendLine($" font-size: {this.Body.FontSize}px;");
            _sb_classLine.AppendLine($" font-family: {this.Body.FontName};");
            _sb_classLine.AppendLine($" background-color: cyan;");
            _sb_classLine.AppendLine("}");

            _styleLine = _sb_classLine.ToString();
        }

        public void BuildStyleBody()
        {
            _sb_classBody.AppendLine(" {");
            _sb_classBody.AppendLine($" width: {Body.Width}px;");
            _sb_classBody.AppendLine($" height: {Body.Height}px;");
            _sb_classBody.AppendLine("}");

            _styleBody = _sb_classBody.ToString();
        }


        public void BuildStyleFooter()
        {
            _sb_classFooter.AppendLine(" {");
            _sb_classFooter.AppendLine($" width: {Footer.Width}px;");
            _sb_classFooter.AppendLine($" height: {Footer.Height}px;");
            _sb_classFooter.AppendLine($" background-color: cornflowerblue;");
            _sb_classFooter.AppendLine("}");

            _styleFooter = _sb_classFooter.ToString();
        }

        public string GeneratePDF(List<Employee> empregados)
        {
            _style = BuildStyle();

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

                if (_countLine == _linesPerPage || countTotal == countFinal)
                {
                    sb.Append(_endBody);

                    sb.Append(_footer);

                    sb.Append(_endPage);

                    if (!(countTotal == countFinal))
                        sb.Append("<div class='quebra-pagina'></div>");

                    builders.Add(sb);

                    sb = new StringBuilder();

                    _countLine = 0;
                }
            }

            return montarHTML(builders);
        }

        public string montarHTML(List<StringBuilder> conteudo)
        {
            var sb = new StringBuilder();

            var novo = _InitHtml.Replace("--style--", _style);

            sb.Append(novo);

            foreach (var pagina in conteudo)
            {
                sb.Append(pagina.ToString());
            }

            sb.Append(_EndHtml);

            var res = sb.ToString();

            return res;
        }
    }

    public class Header
    {
        public bool Paginate { get; set; } = false;
        public bool Day { get; set; } = false;
        public int Width { get; set; } = 2470;
        public int Height { get; set; } = 260;
    }

    public class Body
    {
        public int FontSize { get; set; } = 12;
        public string FontName { get; set; } = "Arial, Helvetica, sans-serif";

        public int MarginLeft { get; set; }
        public int MarginTop { get; set; }
        public int MarginRight { get; set; }
        public int MarginBottom { get; set; }

        public int Width { get; set; } = 2470;
        public int Height { get; set; } = 1700;
    }

    public class Footer
    {
        public bool Paginate { get; set; } = false;
        public int Width { get; set; } = 2470;
        public int Height { get; set; } = 260;
    }


    public enum Alinhamento : short
    {
        Left = 0,
        Center = 1,
        Right = 2
    }

    public enum Colors : short
    {
        Black = 0,
        Green = 1,
        Red = 2,
        Blue = 3,
        Gray = 5,
        Orange = 6
    }
}
