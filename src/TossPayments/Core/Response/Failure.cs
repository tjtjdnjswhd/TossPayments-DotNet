namespace TossPayments.Core.Response;

public class Failure
{
    /// <summary>
    /// 오류 타입을 보여주는 에러 코드입니다.
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// 에러 메시지입니다.에러 발생 이유를 알려줍니다. 최대 길이는 510자입니다.
    /// </summary>
    public required string Message { get; set; }
}