﻿using GameZone.Attributes;
using GameZone.Settings;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.ViewModels
{
    public class CreateGameViewModel
    {
        [MaxLength(255)]
        public string Name { get; set; }=string.Empty;

        [MaxLength(500)]
        public string Desciption { get; set; } = string.Empty;

        [Display(Name ="Category")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }=Enumerable.Empty<SelectListItem>();
        [Display(Name = "Supported Devices")]

        public List<int> SelectedDevices { get; set; } = default!;
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

        [AllowedExtensions(FileSettings.AllowedExtensions)]
        [FileMaxSize(FileSettings.MaxFileSizeInByte)]
        public IFormFile Cover { get; set; } = default!;


    }
}
