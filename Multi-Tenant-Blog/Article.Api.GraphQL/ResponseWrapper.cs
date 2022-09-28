namespace Article.Api.GraphQL
{
    public class ResponseWrapper<T>
    {
        public ResponseWrapper(T data, int totalOfElements)
        {
            TotalOfElements = totalOfElements;
            Data = data;
        }

        public int TotalOfElements { get; }

        public T Data { get; }
    }
}
