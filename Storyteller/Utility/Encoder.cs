namespace Storyteller.Utility {
    public abstract class Encoder<T, F> {

        public abstract T Encode(F obj);

        public abstract F Decode(T data);

    }
}