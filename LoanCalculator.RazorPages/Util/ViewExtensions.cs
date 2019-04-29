using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculator.RazorPages.Util
{
    public static class ViewExtensions
    {


        public static IList<SelectListItem> ToSelectList<T>(this IEnumerable<T> items, 
            Func<T, String> valueFunc, Func<T, String> textFunc)
        {
            return items.Select(n => new SelectListItem
             {
                 Value = valueFunc(n),
                 Text = textFunc(n)
             }).ToList();
        }



    }
}
