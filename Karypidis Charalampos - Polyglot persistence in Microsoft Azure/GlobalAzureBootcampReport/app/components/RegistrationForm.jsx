var React = require('react');
var ReactBootstrap = require('reactBootstrap');

var security = require('../security');

var RegistrationForm = React.createClass({
	
	getInitialState(){
		return {
			userName: '',			
			email: '',
			password: '',
			confirmPassword: ''
		};
	},

	handleChange(e){
		switch (e.target.id) {
			case 'registrationUserName':
				this.setState({userName: e.target.value});
				break;
			case 'registrationEmail':
				this.setState({email: e.target.value});
				break;
			case 'registrationPassword':
				this.setState({
					password: e.target.value,
					confirmPassword: e.target.value
				});
				break;
		}
	},

	register(){
		security.register(this.state);
	},

	render() {
		return(
			<ReactBootstrap.Panel header='Registration' bsStyle='primary'>
				<form className='form-horizontal'>
					<ReactBootstrap.Input type='text' id='registrationUserName' value={this.state.userName} onChange={this.handleChange} label='Username' labelClassName='col-xs-2' wrapperClassName='col-xs-12' />
					<ReactBootstrap.Input type='email' id='registrationEmail' value={this.state.email} onChange={this.handleChange} label='Email' labelClassName='col-xs-2' wrapperClassName='col-xs-12' />
					<ReactBootstrap.Input type='password' id='registrationPassword' value={this.state.password} onChange={this.handleChange} label='Password' labelClassName='col-xs-2' wrapperClassName='col-xs-12' />
					<ReactBootstrap.Button onClick={this.register} bsStyle='primary'>Register</ReactBootstrap.Button>
				</form>
			</ReactBootstrap.Panel>
		);
	}
});

module.exports = RegistrationForm;