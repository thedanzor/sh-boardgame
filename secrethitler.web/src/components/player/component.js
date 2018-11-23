import React, { Component } from 'react';

import JoinServer from './join-server';
import IdentityScreen from './identity-screen';
import GameHeader from '../../ui-components/game-header';
import PlayerCards from '../../ui-components/player-cards';
import JaNeinScreen from '../../ui-components/ja-nein-screen';
import { gameStateStrings } from '../../helpers/gameStateServerTranslator.js';

class PlayerComponent extends Component {
	constructor(props) {
		super(props);
		console.log(props)
		this.state = {
			identityScreenOpen: true,
			game: !props.player.game ? 'login' : gameStateStrings[props.player.game.gameStateId]
			// game: 'Vote-For-Government'
		}
	}
	// componentWillReceiveProps() {
	// 	this.setState({
	// 		game:!this.props.player.game ? 'login' : gameStateStrings[this.props.player.game.gameStateId]
	// 	})
	// }
	render() {
		const { player, actions } = this.props;
		const { userName } = player;

		//fake data.
		const playerList = ["kees", "Sjaak", "Harry", "Barry", "Henk", "Klaas"];
		const electedPlayers = [playerList[0], playerList[1]]
		player.role = 2; //HITLER
		//Component list. This will link each game state to a component. We can give different props for each.
		//TODO: onClick method to voting round (should invoke action, API call and change in store.)
		const components = {
			'login': () => <JoinServer joinServer={actions.joinServer} />,
			'Open': () => null,
			'Choose-President': () => <PlayerCards players={playerList} />,
			'Choose-Chancellor': () => null,
			'Vote-For-Government': () => <JaNeinScreen electedPlayers={electedPlayers} />
		}

		return (
			<div id="game-container">
				<GameHeader playerName={userName} gameState={this.state.game} />
				<div id="game-body">
					{
						components[this.state.game]()
					}
				</div>
				<IdentityScreen toggleScreen={actions.toggleIDScreen} player={player} />
			</div>
		)
	}
}

export default PlayerComponent
