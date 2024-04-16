namespace TossPayments.Core.Request
{
    public class CreateSubmallRequest
    {
        /// <summary>
        /// ������� ID�Դϴ�. �ִ� ���̴� 20���Դϴ�.
        /// </summary>
        public required string SubMallId { get; set; }

        /// <summary>
        /// ��������� ���� �ݾ��� ���޹��� ���� ������ ���� ��ü�Դϴ�.
        /// </summary>
        public required SubmallAccount Account { get; set; }

        /// <summary>
        /// ���޹��� ������ ���� �ڵ��Դϴ�. ���� �ڵ�� ���ǻ� �ڵ带 �����ϼ���.
        /// </summary>
        public required string Bank { get; set; }

        /// <summary>
        /// ���¹�ȣ�Դϴ�. - ���� ���ڸ� �־�� �մϴ�. �ִ� ���̴� 20���Դϴ�.
        /// </summary>
        public required string AccountNumber { get; set; }

        /// <summary>
        /// ���޹��� ������ �������Դϴ�. �ִ� ���̴� ������ ������ �ѱ� 30��, ���� 60���Դϴ�.
        /// </summary>
        public string HolderName { get; set; }

        /// <summary>
        /// ������� Ÿ���Դϴ�. CORPORATE(����), INDIVIDUAL(����) �� �ϳ��� ���� �־��ּ���.
        /// </summary>
        public required SubmallType Type { get; set; }

        /// <summary>
        /// ����� �̸��� �ּ��Դϴ�.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// ����� ����ó�Դϴ�. - ���� ���ڸ� �־�� �մϴ�.
        /// </summary>
        public required string PhoneNumber { get; set; }

        /// <summary>
        /// ������� ��ȣ���Դϴ�. ������� type�� CORPORATE�� �� �ʼ��� ������ �ϴ� �Ķ�����Դϴ�. �ִ� ���̴� ������ ������ �ѱ� 30��, ���� 60���Դϴ�.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// ������� ��ǥ�ڸ��Դϴ�. ������� type�� CORPORATE�� �� �ʼ��� ������ �ϴ� �Ķ�����Դϴ�. �ִ� ���̴� ������ ������ �ѱ� 20��, ���� 40���Դϴ�.
        /// </summary>
        public string RepresentativeName { get; set; }

        /// <summary>
        /// ������� ����ڵ�Ϲ�ȣ �Դϴ�. ������� type�� CORPORATE�� �� �ʼ��� ������ �ϴ� �Ķ�����Դϴ�. ���̴� 10���Դϴ�.
        /// </summary>
        public string BusinessNumber { get; set; }

        /// <summary>
        /// ������� ���õ� �߰� ������ key-value ������ ��� �ִ� ��ü�Դϴ�. �ִ� 50���� key-value ���� ������ �� ������ ��ü ũ��� 4kB ���Ͽ��� �մϴ�. key�� value ��� ���ڿ� �����̾�� �մϴ�.
        /// </summary>
        public Dictionary<string, string>? Metadata { get; set; }
    }
}