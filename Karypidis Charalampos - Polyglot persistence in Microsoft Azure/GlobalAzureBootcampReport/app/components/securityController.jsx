var React = require('react');

var LoginForm = require('./LoginForm');
var RegistrationForm = require('./RegistrationForm');
var UserInfo = require('./UserInfo');
var Footer = require('./Footer');

var security = require('../security');

var SecurityController = React.createClass({
	
	getInitialState(){
		return {
			isAuthenticated : this.props.isAuthenticated,
			user: this.props.user
		};
	},

	componentDidMount(){
		security.addChangeListener(this.onChange);
	},

	render() {
		return (
			this.state.isAuthenticated ? 
				(<div>
					<UserInfo user={this.state.user} />
					<Footer />
				</div>) :
				(<div>
					<LoginForm />
					<RegistrationForm />
					<Footer />
				</div>)
		);
	},

	onChange(status){
		this.setState({
			isAuthenticated: status.isAuthenticated,
			user: status.user
		});
	}
});
 
module.exports = SecurityController;