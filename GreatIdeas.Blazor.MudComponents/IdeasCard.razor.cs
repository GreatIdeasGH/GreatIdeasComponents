using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using GreatIdeas.Extensions;

namespace GreatIdeas.Blazor.MudComponents
{
    public class IdeasCardBase: IdeasIconBase
    {
        ///<summary>Add Components to footer of card</summary>
        [Parameter]
        public RenderFragment Actions { get; set; }

        ///<summary>Enable avator in card header</summary>
        [Parameter]
        public bool ShowAvator { get; set; }

        ///<summary>Add buttons to card header</summary>
        [Parameter]
        public RenderFragment HeaderActions { get; set; }
        
        ///<summary>Image to display</summary>
        [Parameter]
        public string Image { get; set; }

        string Initials() => Title.GetInitials("");
    }
}