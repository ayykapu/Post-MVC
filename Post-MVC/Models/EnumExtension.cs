﻿using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Post_MVC.Models
{
    static public class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }
}