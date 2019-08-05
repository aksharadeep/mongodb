using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public interface ILabelService
    {
        Label GetLabelById(int id);
        List<Label> GetLabels();
        void AddLabel(Label label);
        bool UpdateLabel(int id,Label label);
        bool DeleteLabel(int id);
    }
}
