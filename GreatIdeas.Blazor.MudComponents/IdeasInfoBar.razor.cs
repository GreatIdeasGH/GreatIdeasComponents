using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace GreatIdeas.Blazor.MudComponents
{
    public partial class IdeasInfoBar
    {
        [Parameter]
        public string Content { get; set; }

        [Parameter]
        public Severity Severity { get; set; } = Severity.Info;
        private string Theme()
        {
            return $"pa-2 mt-2 mud-theme-{Severity}";
        }

        [Parameter]
        public bool EnableInfo { get; set; }
    }
}