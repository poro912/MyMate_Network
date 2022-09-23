using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerNetwork.Module.sub
{
	// 로그인 된 사용자의 주소를 저장할 수 있는 사전
	public class LoginClientContainer
	{
		static private LoginClientContainer instance;
		static public LoginClientContainer Instance
		{
			get
			{
				if(instance == null)
					instance = new LoginClientContainer();
				return instance;
			}
		}

		private Dictionary<int, Client> userList;

		public LoginClientContainer()
		{
			userList = new Dictionary<int, Client>();
		}


		public int login(int usercode, Client client)
		{
			if (client == null)
				return -1;
			instance.userList.Add(usercode, client);
			return 1;
		}

		public void logout(int usercode)
		{
			instance.userList.Remove(usercode);
		}

	}
}
