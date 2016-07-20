/// card类
/// 属性有
/// card_id卡牌id，name卡牌名字，power卡牌能量消耗，atk卡牌攻击力，life卡牌生命， skill卡牌技能id， img卡牌图片的名字
/// currentatk打牌时即时攻击力， currentlife打牌时即时生命
/// 方法有
/// 构造函数传入的都是string，在构造函数中会把一些string转成int
/// ToString把所有属性转成string返回，用于调试信息
/// 
/// /// </summary>
using System.Collections;
using System;

namespace BasicCard {
	public class Card {
		int card_id;
		public int Card_Id{
			get{ return card_id;}
			set{ card_id = value;}
		}

		string name;
		public string Name{
			get{ return name;}
			set{ name = value;}
		}

		int power;
		public int Power{
			get{ return power;}
			set{ power = value;}
		}

		int atk;
		public int Atk{
			get{ return atk;}
			set{ atk = value;}
		}

		int life;
		public int Life{
			get{ return life;}
			set{ life = value;}
		}

		int skill;
		public int Skill{
			get{ return skill;}
			set{ skill = value;}
		}

		string img;
		public string Img{
			get{ return img;}
			set{ img = value;}
		}

		int currentLife;
		public int CurrentLife {
			get{ return currentLife;}
			set{ currentLife=value;}
		}

		int currentAtk;
		public int CurrentAtk{
			get{ return currentAtk;}
			set{ currentAtk = value;}
		}

		public Card(string id, string name, string power, string atk, string life, string skill, string i){
			Card_Id = int.Parse(id);
			Name = name;
			Power = int.Parse (power);
			Atk = int.Parse (atk);
			Life = int.Parse (life);
			Skill = int.Parse (skill);
			Img = i;
			CurrentLife = Life;
			CurrentAtk = Atk;
		}

		public string ToString() {
			string tmp;
			tmp = "cardid=" + Card_Id.ToString () + " name=" + Name + " Power=" + Power.ToString () + " atk=" + Atk.ToString () +
			" life=" + Life.ToString () + " skill=" + Skill.ToString () + " img=" + Img + " currentlife=" + CurrentLife.ToString ()
			+ " currentatk=" + CurrentAtk.ToString ();
			return tmp;
		}
	}
}
