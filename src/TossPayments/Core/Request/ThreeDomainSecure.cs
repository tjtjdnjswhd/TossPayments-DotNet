namespace TossPayments.Core.Request
{
    public class ThreeDomainSecure
    {
        /// <summary>
        /// 3D Secure 인증 세션의 인증 값입니다.
        /// </summary>
        public required object Cavv { get; set; }

        /// <summary>
        /// 트랜잭션 ID입니다.
        /// </summary>
        public required object Xid { get; set; }

        /// <summary>
        /// 3DS 인증 결과의 코드 값입니다.
        /// </summary>
        public required object Eci { get; set; }

    }
}