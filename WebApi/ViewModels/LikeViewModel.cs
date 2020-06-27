﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace randomfilm_backend.ViewModels
{
    public class LikeViewModel
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public int AccountId { get; set; }
        public bool LikeOrDislike { get; set; }

        public virtual Account Account { get; set; }
        public virtual Film Film { get; set; }
    }
}
