namespace Oop101
{
    public class Kisi 
    {
        //Access Modifiers
        /*
         * private; sadece tanımlandığı scope içinden erişilebilir
         * internal; sadece aynı namespace(proje) içerisinden erişilebilir
         * public; referans verilen tüm projelerden erişilebilir
         * protected; sadece kalıtım içerisinden erişilebilir
         * protected internal; sadece kalıtımdan ve aynı namespace(proje) den erişilebilir
         */
        

        private string _ad; //field
        private string _soyad;
        private DateTime _dogumTarihi;

        public string Ad //full-property
        {
            get => _ad.ToUpper();
            set
            {
                foreach (char harf in value)
                {
                    if (char.IsDigit(harf))
                        throw new Exception("Adınızda rakam bulunamaz");
                }
                _ad = value;
            }
        }
        public string Soyad //full-property
        {
            get => _soyad;
            set => _soyad = value;
        }

        public DateTime DogumTarihi { get; set; } //auto-property

        public int Yas => DateTime.Now.Year - _dogumTarihi.Year; // read-only property
    }
}
