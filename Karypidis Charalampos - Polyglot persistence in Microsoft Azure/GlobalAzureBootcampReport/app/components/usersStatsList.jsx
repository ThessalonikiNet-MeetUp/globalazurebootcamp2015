var React = require('react');
var ReactBootstrap = require('reactBootstrap');

var usersStats = require('../usersStats');

var UsersStatsList = React.createClass({
	
	getInitialState(){
		return {stats: this.props.usersStats};
	},

	componentDidMount(){
		usersStats.addChangeListener(this.onChange);
	},

	render() {
		var stats = this.state.stats.map(userStat =>
			<li>
				<div className="userImage">
					<a href={userStat.ProfileUrl} target="_blank">
						<img src={userStat.ImageUrl} />
					</a>
				</div>
				<div className="userInfo">
					<div className="userName"><a href={userStat.ProfileUrl} target="_blank">@{userStat.Name}</a></div>
					<div className="userCounter">{userStat.TweetsNumber} tweets</div>
				</div>
			</li>
		);

		return (		
			<ReactBootstrap.Panel className="userStats" header='Users Statistcis' bsStyle='info'>				
				<ul>
					{stats}
				</ul>
			</ReactBootstrap.Panel>
		);
	},

	onChange(newStats){
		this.setState({stats: newStats});
	}

});

module.exports = UsersStatsList;