using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Carteira.Helpers
{
    [HtmlTargetElement("input-for", TagStructure = TagStructure.WithoutEndTag)]
    public class InputForTagHelper : TagHelper
    {
        public ModelExpression Model { get; set; }

        public bool showLabel { get; set; } = true;
        public bool selectShowId { get; set; } = false;

        //https://medium.com/@dmitrysikorsky/asp-net-core-custom-drop-down-list-86bcd60f2cf2
        //https://stackoverflow.com/questions/34624034/select-tag-helper-in-asp-net-core-mvc

        //ESTUDAR
        //https://www.intertech.com/Blog/introducing-asp-net-core-mvc-tag-helpers/
        //https://www.programmingwithwolfgang.com/understanding-tag-helpers-in-asp-net-core-mvc/
        //https://visualstudiomagazine.com/articles/2019/05/01/creating-custom-tag-helpers.aspx

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var Label = new TagBuilder("label");
            if (showLabel)
            {
                Label.AddCssClass("control-label");
                Label.Attributes.Add("for", Model.Name);
                Label.InnerHtml.AppendHtml(Model.Metadata.DisplayName?? Model.Name);
            }

            output.SuppressOutput();

            var InputSelect = new TagBuilder("select");
            InputSelect.AddCssClass("custom-select");

            InputSelect.Attributes.Add("Id", Model.Name);
            InputSelect.Attributes.Add("Name", Model.Name);

            var SelectItem = new TagBuilder("option");

            if (Model.Metadata.IsEnum)
            {
                IEnumerable<KeyValuePair<string, string>> valuesOfEnum;
                if(selectShowId)
                    valuesOfEnum = Model.Metadata.EnumGroupedDisplayNamesAndValues
                    .SelectMany(m => new Dictionary<string, string> { {  m.Value, m.Value + " - " + m.Key.Name} });
                else
                    valuesOfEnum = Model.Metadata.EnumGroupedDisplayNamesAndValues
                    .SelectMany(m => new Dictionary<string, string> { { m.Value, m.Key.Name } });

                foreach (var item in valuesOfEnum)
                {
                    TagBuilder option = new TagBuilder("option");
                    option.MergeAttribute("value", item.Key);

                    // Se houver valor para o campo, seta ele com o valor correspondente (Na edição de registros)
                    if (Model.Model != null)
                    {
                        var entity = Model.ModelExplorer.Container.Model;
                        var valueOfField = (short) entity.GetType().GetProperty(Model.Name).GetValue(entity);
                        var valueOfEnum = short.Parse(item.Key);

                        if (valueOfField == valueOfEnum)
                            option.MergeAttribute("selected", "");
                    }

                    option.InnerHtml.AppendHtml(item.Value);
                    InputSelect.InnerHtml.AppendHtml(option);
                }
            }

            if(showLabel)
                output.Content.AppendHtml(Label);

            var Validator = new TagBuilder("span");
            Validator.AddCssClass("text-danger");
            Validator.AddCssClass("field-validation-valid");
            Validator.Attributes.Add("data-valmsg-for", Model.Name);
            Validator.Attributes.Add("data-valmsg-replace", "true");
            //InputSelect.InnerHtml.AppendHtml(Validator);

            output.Content.AppendHtml(InputSelect);
            output.Content.AppendHtml(Validator);

            base.Process(context, output);
        }
    }
}
