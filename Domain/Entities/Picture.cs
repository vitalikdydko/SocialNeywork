﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
  public class Picture
    {
      public int Id { get; set; }
      public int UserId { get; set; }
      public byte[] ImageData { get; set; }
      public string ImageMineType { get; set; }
    }
}
