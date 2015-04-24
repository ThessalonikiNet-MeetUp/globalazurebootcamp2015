var React = require('react');
var ReactBootstrap = require('reactBootstrap');

var security = require('../security');

var UserInfo = React.createClass({
	
	logout(){
		security.logout();
	},

	render() {
		var Panel = ReactBootstrap.Panel;
		var Button = ReactBootstrap.Button;
		var user = this.props.user;
		return(
			<Panel header='User Info' bsStyle='primary'>
				<div>
					UserName: {user.UserName}
				</div>
				<div>
					Email: {user.Email}
				</div>
				<Button onClick={this.logout} bsStyle='primary'>Log out</Button>
			</Panel>
		);
	}
});

module.exports = UserInfo;