class ApplicationController < ActionController::Base
  before_filter :setname
  before_filter :set_locale
  protect_from_forgery
  def default_url_options(options={})
    logger.debug "default_url_options is passed options: #{options.inspect}\n"
    { :locale => I18n.locale }
  end
  private

  def set_locale
    I18n.locale = params[:locale] || I18n.default_locale
  end


  def setname
    if user_signed_in?
      unless !!current_user.profile.name
      redirect_to edit_profile_path(current_user.profile)
      end
    end
  end

end
