﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardApp.Web.ViewModels.Task
{
    public class TaskViewModel
    {
        public string Id { get; set; } = null;
        public string Title { get; set; }
        public string Description { get; set; }

        public string Owner { get; set; }
    }
}
