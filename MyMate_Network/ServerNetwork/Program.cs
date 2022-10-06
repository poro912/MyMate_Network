// See https://aka.ms/new-console-template for more information
//
// C#소켓 통신 방법 : https://luv-n-interest.tistory.com/1093
// https://www.sysnet.pe.kr/2/0/12856
//

// 서버 통신을 위한 using
using Protocol;
using ServerNetwork;
using ServerNetwork.Module;
//using Protocol.trash;

Console.WriteLine("Start Server");

// 델리게이트 때문에 넣은 임시 메소드
Temp temp = new();

// 서버 통신을 여는 문장.
Server server = Server.Instance;

// 델리게이트 세팅
server.clientAccept = new ClientAccept(temp.Accept);

// 데이터를 받기위한 변수들
KeyValuePair<byte, object?> result;
byte[]? a_data = new byte[1024];
List<byte> l_data = new();

while (true)
{
	a_data = null;
	// cpu 부하를 줄이기 위한 스레드 sleep
	Thread.Sleep(1000);

	// Clinet 를 확인하여 입력된 데이터가 있는지 확인
	temp.client.receive.Pop(out a_data);

	// a_data = temp.client.receive.Pop();
	if (a_data != null)
	{
		// 입력된 데이터를 Key Value 로 변환
		result = Converter.Convert(ref a_data);

		// 변환시 값이 없다면 null 반환
		if (result.Value == null)
			continue;

		Console.WriteLine("전송받은 데이터 타입 : " + result.Key);
		Console.WriteLine("전송받은 데이터 : " + result.Value);

		// 데이터가 로그인 데이터 라면
		if (result.Key == Protocol.DataType.LOGIN)
		{
			// 임시 객체 생성
			LoginProtocol.Login login = new();

			// 두 방법 중 편한 것으로 하면 된다.
			login = (LoginProtocol.Login)result.Value;
			//(result.Value as LoginProtocol.Login).Get(out login.id, out login.pw);
			
			// 결과 출력
			Console.WriteLine("로그인 시도");
			Console.WriteLine("id : " + login.id);
			Console.WriteLine("pw : " + login.pw);
		}

		//server.send.Data(l_data);
	}

} 

