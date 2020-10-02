namespace Mobiiliohjelmointi_task_4
{
    class AddressFromApi
    {

        public int id { get; set; }
        public string nimi { get; set; }
        public string osoite { get; set; }
        public string puhelin { get; set; }
        public string syntyma_aika { get; set; }
        public AddressFromApi(int id, string nimi, string osoite, string puhelin, string syntyma_aika)
        {
            this.id = id;
            this.nimi = nimi;
            this.osoite = osoite;
            this.puhelin = puhelin;
            this.syntyma_aika = syntyma_aika;
        }

    }
}
