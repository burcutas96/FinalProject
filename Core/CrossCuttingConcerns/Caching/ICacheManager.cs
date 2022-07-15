namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        //Baştaki T'de T döndürüceğimizi belirttik. Get<T>'de ise hangi tipte tuttuğumuzu belirttik.
        T Get<T>(string key);   

        object Get(string key);

        //value, object türünde çünkü biz buraya her türlü datayı atayabiliriz.
        //duration, bu cachede durma süresidir. Dakika ya da saat cinsinden istediğimiz değeri verebiliriz.
        void Add(string key, object value, int duration);

        bool IsAdd(string key); //cache'de var mı diye kontrol edicez.

        void Remove(string key);

        void RemoveByPattern(string pattern); //Mesela metot isminin içinde 'Category' olanları sil gibi bir pattern vericez.
    }
}
