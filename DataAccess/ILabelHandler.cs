using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
  public  interface ILabelHandler
    {
        List<Label> GetLabels();
        Label GetLabelById(int id);
        void AddLabel(Label label);
        bool UpdateLabel(int id,Label label);
        bool DeleteLabel(int id);
    }
}
