﻿using System;

namespace Smarket.API.Model.CommomModels
{
    public class CategoryModel
    {
        public Guid     CategoryId  { get; set; }

        public string   Description { get; set; }

        public string   Image       { get; set; }
    }
}
