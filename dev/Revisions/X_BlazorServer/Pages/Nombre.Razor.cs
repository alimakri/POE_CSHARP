using Microsoft.AspNetCore.Components;

namespace X_BlazorServer.Pages
{
    public class NombreBase : ComponentBase
    {
        protected const int NbMax = 100;
        protected int Value;
        protected int NbMagic;
        protected bool? Gagne;
        protected bool TropPetit;
        protected int NbVies = 7;
        protected void Rejouer()
        {
            var alea = new Random();
            NbMagic = alea.Next(NbMax);
            NbVies = 7;
            Gagne = null;
            Value = 0;
        }
        protected void TestNumber()
        {
            if (Value == NbMagic) Gagne = true;
            else
            {
                NbVies--;
                if (NbVies == 0) Gagne = false;
                TropPetit = Value > NbMagic;
            }
        }
        protected override void OnInitialized()
        {
            Rejouer();
            base.OnInitialized();
        }
    }
}
