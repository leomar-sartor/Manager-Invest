using System.Text;

namespace Carteira.Utility
{
    public static class TemplateGenerator
    {
        public static string GetHTMLString()
        {
            var employees = DataStorage.GetEmployees();

            var sb = new StringBuilder();

            sb.Append
            (
                @"
                    <html>
                        <head>
                        </head>

                        <body>
        
        <table>
                "
            );

            foreach (var emp in employees)
            {
                sb.AppendFormat
                (
                    @"
                        <tr>
                            <td> {0} </td>
                            <td> {1} </td>
                            <td> {2} </td>
                            <td> {3} </td>
                        </tr>
                    ",
                    emp.Name,
                    emp.LastName,
                    emp.Age,
                    emp.Gender
                );
            }

            sb.Append
            (
                @"
</table>

                        </body>
                    <html>
                "
            );

            return sb.ToString();
        }
    }
}
