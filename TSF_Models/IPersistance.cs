using System;
using System.Collections.Generic;
using System.Text;

namespace TSF_Models
{
    public interface IPersistance
    {
        public IEnumerable<Cinema> ChargeCinema();

        void EnregistreCinema(IEnumerable<Cinema> cinema);
    }
}
