var React = require('react');
var ReactBootstrap = require('reactBootstrap');

var NavigationBar = require('./navigationBar');
var UsersStatsList = require('./usersStatsList');
var TweetsList = require('./tweetsList');
var SecurityController = require('./securityController');

class App extends React.Component {
  render() {
	var Grid = ReactBootstrap.Grid;
	var Row = ReactBootstrap.Row;
	var Col = ReactBootstrap.Col;
	
	return (
		<div>
			<NavigationBar />
			<Grid fluid={false} >
				<Row>
					<Col xs={12} md={3}>
						<UsersStatsList usersStats={this.props.initialStats} />
					</Col>
					<Col xs={12} md={6}>
						<TweetsList tweets={this.props.initialTweets} />
					</Col>
					<Col xs={12} md={3}>
						<SecurityController isAuthenticated={this.props.isAuthenticated} user={this.props.user}/>
					</Col>
				</Row>
			</Grid>
		</div>
	);
  }
}

module.exports = App;