// gam-tic-tac-toe.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <stdio.h>
#include <iostream>
#include <ctime>

using namespace std;

typedef struct {
	char psymbol;
	int choose;   // choose = number
	int space[9];
}player_type;

typedef struct {
	char space[9];
	bool playing;
	char winner;
}board_type;

void drawnBoard(char* space);
// void play(char *space, char player);
// void bot(char* space, char playerbot);
//bool check_winner(char* space, char playerbot, char player);

void play(board_type* t, player_type* player);
void bot(board_type* t, player_type* bot_player);
void init_Board(board_type* t);
bool chek_board_Is_full(board_type* t);
void init_play(player_type* p);
bool check_winner(board_type* pboard, player_type* phuman, player_type* pbot);

player_type human;
player_type robot;
board_type board;

int number;
int number2;

int main()
{
	//char space[9] = { ' ', ' ', ' ' , ' ',' ' ,' ' , ' ', ' ', ' ' };
	//char player = 'x';
	//char playerbot = 'O';
	//bool running = true;
	// drawnBoard(space);
	init_Board(&board);
	drawnBoard(board.space);
	human.psymbol = 'X';
	robot.psymbol = 'O';
	init_play(&human);
	init_play(&robot);
	
	board.playing = true;
	while (board.playing)
	{
		// play(space,player);
		play(&board, &human);
		// drawnBoard(space);
		drawnBoard(board.space);
		if (check_winner(&board, &human, &robot))
		{
			board.playing = false;
			cout << board.winner << " is the Winner !!!" << "\r\n";
			cout << "End Game ";
		}
		//bot(space, playerbot);
		bot(&board, &robot);
		drawnBoard(board.space);
		if (check_winner(&board, &human, &robot))
		{
			board.playing = false;
			cout << board.winner << " is the Winner !!!" << "\r\n";
			cout << "End Game ";
		}
		if (chek_board_Is_full(&board)&&board.playing)
		{
			cout << "board is full. result is draw" << "\r\n";
			board.playing = false;
		}

	}
	return 0;
}

void init_Board(board_type *t)
{
	for (int i = 0; i < 9; i++)
	{
		t->space[i] = ' ';
	}
}

void init_play(player_type *p)
{
	for (int i = 0; i < 9; i++)
	{
		p->space[i] = 0;
	}
}

void drawnBoard(char* space)
{

	cout << "     |     |     " << "\r\n";
	cout << "  " << space[0] << "  |  " << space[1] << "  |  " << space[2] << "  |  " << endl;
	cout << "_____|_____|_____" << endl;
	cout << "     |     |     " << "\r\n";
	cout << "  " << space[3] << "  |  " << space[4] << "  |  " << space[5] << "  |  " << endl;
	cout << "_____|_____|_____" << endl;
	cout << "     |     |     " << "\r\n";
	cout << "  " << space[6] << "  |  " << space[7] << "  |  " << space[8] << "  |  " << endl;
	cout << "     |     |     " << "\r\n";
	cout << "                 " << "\r\n";

}

void play(board_type* t, player_type* player)
{

	//  while ( number > 0 || number < 8 )
	// {
	// 	cout << "enter number for spot 0-9 = ";
	// 	cin >> number;
	// 	number--;
	// 	if (space[number] == ' ')
	// 	{
	// 		space[number] = player;
	// 		break;
	// 	}
	// }
	bool make_choice = true;
	while (make_choice)
	{
		cout << "enter number for spot 1-9 = ";
		cin >> player->choose;
		if ((player->choose > 9) || (player->choose < 1))
			cout << "Error choic choose a new one ";
		else {
			player->choose--;
			if (t->space[player->choose] == ' ')
			{
				t->space[player->choose] = player->psymbol;
				player->space[player->choose] = 1;
				make_choice = false;
			}
		}
	}
}

void bot(board_type* t, player_type* bot_player)
{
	srand(time(0));
	//while (true)
	//{
	//	number2 = rand() % 9;
	//	if (space[number2] == ' ')
	//	{
	//		space[number2] = playerbot;
	//		break;
	//	}
	//}
	bool make_choice = true;
	while (make_choice)
	{
		bot_player->choose = rand() % 9;
		if (t->space[bot_player->choose] == ' ')
		{
			t->space[bot_player->choose] = bot_player->psymbol;
			bot_player->space[bot_player->choose] = 1;
			make_choice = false;
		}
	}
}

bool chek_board_Is_full(board_type *t)
{
	int empety_space = 0;
	for (int i = 0; i < 9; i++)
	{
		if (t->space[i] == ' ')
			empety_space += 1;
	}
	if (empety_space == 0)
		return true;
	return false;
}

bool check_winner(board_type *pboard, player_type *phuman, player_type *pbot)
{
	int score_row1=0,score_row2=0,score_row3=0;
	int score_col1 = 0, score_col2 = 0, score_col3 = 0;
	int score_crossR = 0, score_crossL = 0;
	// Is human win?
	score_row1 = phuman->space[0] + phuman->space[1]+ phuman->space[2];
	score_row2 = phuman->space[3] + phuman->space[4] + phuman->space[5];
	score_row3 = phuman->space[6] + phuman->space[7] + phuman->space[8];

	score_col1 = phuman->space[0] + phuman->space[3] + phuman->space[6];
	score_col2 = phuman->space[1] + phuman->space[4] + phuman->space[7];
	score_col3 = phuman->space[2] + phuman->space[5] + phuman->space[8];

	score_crossR = phuman->space[0] + phuman->space[4] + phuman->space[8];
	score_crossL = phuman->space[2] + phuman->space[4] + phuman->space[6];

	score_row1 /= 3;
	score_row2 /= 3;
	score_row3 /= 3;

	score_col1 /= 3;
	score_col2 /= 3;
	score_col3 /= 3;

	score_crossL /= 3;
	score_crossR /= 3;
	if (score_row1 || score_row2 || score_row3 || score_col1 || score_col2 || score_col3 || score_crossL || score_crossR)
	{
		pboard->winner = phuman->psymbol;
		//pboard->playing = false;
		return(1);
	}


	// Is bot win?
	score_row1 = pbot->space[0] + pbot->space[1] + pbot->space[2];
	score_row2 = pbot->space[3] + pbot->space[4] + pbot->space[5];
	score_row3 = pbot->space[6] + pbot->space[7] + pbot->space[8];

	score_col1 = pbot->space[0] + pbot->space[3] + pbot->space[6];
	score_col2 = pbot->space[1] + pbot->space[4] + pbot->space[7];
	score_col3 = pbot->space[2] + pbot->space[5] + pbot->space[8];

	score_crossR = pbot->space[0] + pbot->space[4] + pbot->space[8];
	score_crossL = pbot->space[2] + pbot->space[4] + pbot->space[6];

	score_row1 /= 3;
	score_row2 /= 3;
	score_row3 /= 3;

	score_col1 /= 3;
	score_col2 /= 3;
	score_col3 /= 3;

	score_crossL /= 3;
	score_crossR /= 3;
	if (score_row1 || score_row2 || score_row3 || score_col1 || score_col2 || score_col3 || score_crossL || score_crossR)
	{
		pboard->winner = pbot->psymbol;
		//pboard->playing = false;
		return(1);
	}
	return(0);
	/*if (space[0] != ' ' && space[0] == space[1] && space[1] == space[2])
	{
		space[0] == player ? cout << "YOU WIN \n" : cout << "You lose\n";
	}
	else if (space[0] != ' ' && space[0] == space[3] && space[3] == space[6])
	{
		space[0] == player ? cout << "YOU WIN \n" : cout << "You lose\n";
	}
	else if (space[1] != ' ' && space[1] == space[4] && space[4] == space[7])
	{
		space[1] == player ? cout << "YOU WIN \n" : cout << "You lose\n";
	}
	else if (space[2] != ' ' && space[2] == space[5] && space[5] == space[8])
	{
		space[2] == player ? cout << "YOU WIN \n" : cout << "You lose\n";
	}
	else if (space[6] != ' ' && space[6] == space[7] && space[7] == space[8])
	{
		space[6] == player ? cout << "YOU WIN \n" : cout << "You lose\n";
	}
	else if (space[3] != ' ' && space[3] == space[4] && space[4] == space[5])
	{
		space[3] == player ? cout << "YOU WIN \n" : cout << "You lose\n";
	}
	else
	{

	}*/

	return(0);
}