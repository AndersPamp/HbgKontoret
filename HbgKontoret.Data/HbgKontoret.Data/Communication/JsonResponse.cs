namespace HbgKontoret.Data.Communication
{
  public class JsonResponse
  {
    public bool Error { get; set; } = false;
    public string Message { get; set; } = "Det är Erlas fel!";
    public dynamic Data { get; set; }
    public int TotalHits { get; set; }
    public int Page { get; set; }
  }
}
