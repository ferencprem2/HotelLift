using System;
namespace Hotellift
{
	public class Lift
	{
		private DateOnly useTime;
		private int cardNumber;
		private int startingFloor;
		private int destinationFloor;



		public Lift(DateOnly useTime, int cardNumber, int startingFloor, int destinationFloor)
		{
			this.useTime = useTime;
			this.cardNumber = cardNumber;
			this.startingFloor = startingFloor;
			this.destinationFloor = destinationFloor;

		}

        public DateOnly UseTime { get => useTime; set => useTime = value; }
        public int CardNumber { get => cardNumber; set => cardNumber = value; }
        public int StartingFloor { get => startingFloor; set => startingFloor = value; }
        public int DestinationFloor { get => destinationFloor; set => destinationFloor = value; }
    }
}

