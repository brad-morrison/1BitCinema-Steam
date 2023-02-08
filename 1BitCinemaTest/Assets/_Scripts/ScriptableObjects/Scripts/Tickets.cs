using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tickets", menuName = "1BitCinema/Databases/Tickets")]
public class Tickets : ScriptableObject
{
    public List<TicketCategory> tickets = new List<TicketCategory>();
}
